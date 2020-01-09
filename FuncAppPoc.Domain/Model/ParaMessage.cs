using System;
using System.Collections.Generic;
using System.Text;

namespace FuncAppPoc.Domain.Model
{
    public class ParaMessage : ParaBase
    {
       
        public ParaMessage()
        {
            Created = DateTime.Now;
        }

        /// <summary>
        /// Paragraph Content
        /// </summary>
        public string Content { get; set; }       
       
    }
}