using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingConsole.Command
{
    public interface ICommand
    {

        #region Properties

        /// <summary>
        /// Full flag name(for example --print)
        /// </summary>
        public string FullFlag { get; set; }

        /// <summary>
        /// Short flag name(for example -p)
        /// </summary>
        public string ShortFlag { get; set; }
        /// <summary>
        /// Descrption is used to print help
        /// </summary>
        public string Description { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Provided needed data to execute command
        /// </summary>
        /// <param name="data">data</param>
        public void SetData(params object[] data);

        /// <summary>
        /// Execute command
        /// </summary>
        public void Execute();

        #endregion Methods
    }
}
