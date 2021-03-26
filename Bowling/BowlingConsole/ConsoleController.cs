using System;
using System.Collections.Generic;
using System.Text;
using BowlingConsole.Command;
using BowlingConsole.Util;
using Bowling;

namespace BowlingConsole
{
    public class ConsoleController : Controller
    {
        protected ICommand command;

        public ConsoleController(CommandFactory factory, string[] args) : base(factory, args)
        {
        }

        #region MainBranches

        /// <summary>
        /// Execute HelpBranch or ParseBranch if args are not empty. Otherwise exit program with fail message.
        /// </summary>
        public override void Run()
        {
            if(args.Length > 0)
            {
                // First arg must be help to execute HelpBranch
                if (args[0].Equals(Constants.HELP_COMMAND_FULL_FLAG) || args[0].Equals(Constants.HELP_COMMAND_SHORT_FLAG))
                {
                    HelpBranch();
                }
                // Otherwise first arg must be filename to data.
                else
                {
                    ParseBranch();
                }
            }
            else
            {
                ExecuteErrorCommand("No arg found. You must give filename to data at least.");
                ExitFailed();
            }
        }

        /// <summary>
        /// Print descriptions for commands
        /// </summary>
        protected void HelpBranch()
        {
            command = factory.CreateCommand(Constants.HELP_COMMAND_FULL_FLAG);

            if (args.Length > 1)
            {
                object[] data = new object[args.Length];
                data[0] = factory;
                for (int i = 1; i < args.Length; i++)
                    data[i] = args[i];
                command.SetData(data);
                command.Execute();
            }
            else
            {
                command.SetData(factory);
                command.Execute();
            }
        }

        /// <summary>
        /// Parse data and create output
        /// </summary>
        protected void ParseBranch()
        {
            try
            {
                IParser parser = new FileParser(args[0]);
                ICollection<BowlingScore> scores = parser.Parse();

                if(args.Length > 1)
                {
                    FlagedScoreCounterBranch(ref scores);
                }
                else
                {
                    SimpleScoreCounterBranch(ref scores);
                }

            }catch(Exception ex)
            {
                ExecuteErrorCommand("Can not parse file: " + args[0]);
                ExitFailed();
            }
        }  

        /// <summary>
        /// If args contains only filename, use default options.
        /// </summary>
        /// <param name="scores">Collection of BowlingScore</param>
        protected void SimpleScoreCounterBranch(ref ICollection<BowlingScore> scores)
        {
            IBowling bowling = new SimpleBowling();
            CountFinalScore(ref bowling, ref scores);

            IOutput output = new HTMLOutput();
            CreateOutput(ref output, GetDefaultFilename(ref output), ref scores);
        }

        /// <summary>
        /// If args contains more then filename, then process all flags
        /// </summary>
        /// <param name="scores">Collection of BowlingScore</param>
        protected void FlagedScoreCounterBranch(ref ICollection<BowlingScore> scores)
        {
            IBowling bowling;
            TypeBowlingBranch(out bowling);
            CountFinalScore(ref bowling, ref scores);

            IOutput output;
            TypeOutputBranch(out output);
            var filename = NoFileBranch(ref output);
            if(output is HTMLOutput)
            {
                HTMLTemplatePathBranch(ref output);
            }
            dynamic content = CreateOutput(ref output, filename, ref scores);
            PrintOutputBranch(content);
        }

        #endregion MainBranches

        #region FlagBranches

        /// <summary>
        /// Set custom or default Bowling
        /// </summary>
        /// <param name="bowling">Bowling</param>
        protected void TypeBowlingBranch(out IBowling bowling)
        {
            string arg;
            if((arg = ArgsContainsFlag(Constants.BOWLING_TYPE_COMMAND_FULL_FLAG, Constants.BOWLING_TYPE_COMMAND_SHORT_FLAG)) != null)
            {
                try
                {
                    command = factory.CreateCommand(Constants.BOWLING_TYPE_COMMAND_FULL_FLAG);
                    command.SetData(arg);
                    command.Execute();

                    bowling = ((BowlingTypeCommand)command).Bowling;

                }catch(Exception ex)
                {
                    ExecuteErrorCommand("Can not found type of bowling.", "Use simple type.");
                    bowling = new SimpleBowling();
                }
            }
            else
            {
                bowling = new SimpleBowling();
            }
        }

        /// <summary>
        /// Set custom or defualt Output
        /// </summary>
        /// <param name="output"></param>
        protected void TypeOutputBranch(out IOutput output)
        {
            string arg;
            if((arg = ArgsContainsFlag(Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG, Constants.OUTPUT_TYPE_COMMAND_SHORT_FLAG)) != null)
            {
                try
                {
                    command = factory.CreateCommand(Constants.OUTPUT_TYPE_COMMAND_FULL_FLAG);
                    command.SetData(arg);
                    command.Execute();

                    output = ((OutputTypeCommand)command).Output;
                }catch(Exception ex)
                {
                    ExecuteErrorCommand("Can not found type output.", "Use html type.");
                    output = new HTMLOutput();
                }
            }
            else
            {
                output = new HTMLOutput();
            }
        }

        /// <summary>
        /// Check if output file generating was blocked by flag
        /// </summary>
        /// <param name="output">Output</param>
        /// <returns>Filename</returns>
        protected string NoFileBranch(ref IOutput output)
        {
            string arg;
            if((arg = ArgsContainsFlag(Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG, Constants.OUTPUT_GENERATE_FILE_COMMAND_SHORT_FLAG)) != null)
            {
                command = factory.CreateCommand(Constants.OUTPUT_GENERATE_FILE_COMMAND_FULL_FLAG);
                command.SetData(output);
                command.Execute();
            }
            else
            {
                return OutputFilenameBranch(ref output);
            }
            return GetDefaultFilename(ref output);
        }

        /// <summary>
        /// Print output content if args contains flag
        /// </summary>
        /// <param name="content">content</param>
        protected void PrintOutputBranch(dynamic content)
        {
            string arg;
            if ((arg = ArgsContainsFlag(Constants.PRINT_COMMAND_FULL_FLAG, Constants.PRINT_COMMAND_SHORT_FLAG)) != null)
            {
                command = factory.CreateCommand(Constants.PRINT_COMMAND_FULL_FLAG);
                command.SetData(content);
                command.Execute();
            }
        }

        /// <summary>
        /// Use custom filename or use default filename
        /// </summary>
        /// <param name="output">Output</param>
        /// <returns>Filename</returns>
        protected string OutputFilenameBranch(ref IOutput output)
        {
            string arg;
            if ((arg = ArgsContainsFlag(Constants.OUTPUT_COMMAND_FULL_FLAG, Constants.OUTPUT_COMMAND_SHORT_FLAG)) != null)
            {
                try
                {
                    command = factory.CreateCommand(Constants.OUTPUT_COMMAND_FULL_FLAG);
                    command.SetData(arg);
                    command.Execute();
                    return ((OutputCommand)command).Filename;
                }
                catch (Exception ex)
                {
                    ExecuteErrorCommand("Failed read filename.", "Use default filename.");
                }
            }
            return GetDefaultFilename(ref output);
        }

        /// <summary>
        /// Set template path if flag found
        /// </summary>
        /// <param name="output">Output</param>
        protected void HTMLTemplatePathBranch(ref IOutput output)
        {
            string arg;
            if ((arg = ArgsContainsFlag(Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG, Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_SHORT_FLAG)) != null)
            {
                try
                {
                    command = factory.CreateCommand(Constants.HTML_OUTPUT_TEMPLATE_PATH_COMMAND_FULL_FLAG);
                    command.SetData(output, arg);
                    command.Execute();
                }catch(Exception ex)
                {
                    ExecuteErrorCommand("Can not found template");
                    ExitFailed();
                }
            }
        }

        #endregion FlagBranches

        #region Tasks

        /// <summary>
        /// Print Error message
        /// </summary>
        /// <param name="data">messages</param>
        protected void ExecuteErrorCommand(params object[] data)
        {
            command = factory.CreateCommand(Constants.ERROR_COMMAND_FACTORY_FLAG);
            command.SetData(data);
            command.Execute();
            
        }

        /// <summary>
        /// Exit program with fail(-1)
        /// </summary>
        protected void ExitFailed()
        {
            Environment.Exit(-1);
        }

        /// <summary>
        /// Count final score for every one BowlingScore in collection
        /// </summary>
        /// <param name="bowling">Bowling</param>
        /// <param name="scores">Collection of BowlingScore</param>
        protected void CountFinalScore(ref IBowling bowling, ref ICollection<BowlingScore> scores)
        {
            try
            {
                var it = scores.GetEnumerator();
                it.MoveNext();
                while (it.Current != null)
                {
                    BowlingScore score = it.Current;
                    bowling.CountScore(ref score);
                    it.MoveNext();
                }
            }
            catch (Exception ex)
            {
                ExecuteErrorCommand("Can not count final score. Please check file");
                ExitFailed();
            }
        }

        /// <summary>
        /// Create output
        /// </summary>
        /// <param name="output">Output</param>
        /// <param name="filename">Filename used in generating file</param>
        /// <param name="scores">Collection of BowlingScore</param>
        /// <returns>Output content</returns>
        protected dynamic CreateOutput(ref IOutput output, string filename, ref ICollection<BowlingScore> scores)
        {
            try
            {
                return output.CreateOutput(ref scores, filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ExecuteErrorCommand("Can not created output. Please check file");
                ExitFailed();
            }
            return null;
        }

        #endregion Tasks

        #region HelperMethods

        /// <summary>
        /// Get defualt filename by output type.
        /// </summary>
        /// <param name="output">Output</param>
        /// <returns>Filename</returns>
        protected string GetDefaultFilename(ref IOutput output)
        {
            if (output is PDFOutput) return "table.pdf";
            if (output is HTMLOutput) return "table.html";
            return "result.txt";
        }

        /// <summary>
        /// Find flags in args
        /// </summary>
        /// <param name="fullFlag">Full flag</param>
        /// <param name="shortFlag">Short flag</param>
        /// <returns>arg if found or empty string</returns>
        protected string ArgsContainsFlag(string fullFlag, string shortFlag)
        {
            fullFlag = fullFlag.ToLower();
            shortFlag = shortFlag.ToLower();
            foreach (var arg in args)
            {
                if (arg.StartsWith(fullFlag)) return arg;
                if (arg.StartsWith(shortFlag)) return arg;
            }
            return null;
        }

        #endregion HelperMethods
    }
}
