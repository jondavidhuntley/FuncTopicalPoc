using System;
using System.Collections.Generic;
using System.Text;

namespace FuncAppPoc.Domain.Model
{
    public class ParaMessage : ParaBase
    {
        public ParaMessage() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        public ParaMessage(string title, string author) : base (title, author)
        {            
        }

        /// <summary>
        /// Paragraph Sample
        /// </summary>
        public string Sample { get; set; }       
       
    }
}