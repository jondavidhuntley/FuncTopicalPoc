﻿using FuncAppPoc.Domain.Enum;
using FuncAppPoc.Guards;
using System;

namespace FuncAppPoc.Domain
{
    /// <summary>
    /// Paragraph Base (Book)
    /// </summary>
    public abstract class ParaBase
    {        
        protected ParaBase()
        {
            Created = DateTime.Now;
        }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        protected ParaBase(string title, string author)
        {
            Guard.AgainstNullOrWhitespace(title, nameof(title));
            Guard.AgainstNullOrWhitespace(author, nameof(author));

            Title = title;
            Author = author;
            Created = DateTime.Now;
        }

        /// <summary>
        /// Year
        /// </summary>
        public int Year
        {
            get
            {
                return Published.Year;
            }
        }

        /// <summary>
        /// Previous year
        /// </summary>
        public int PreviousYear
        {
            get
            {
                return Year - 1;
            }
        }

        /// <summary>
        /// Book Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Book Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Published Date
        /// </summary>
        public DateTime Published { get; set; }

        /// <summary>
        /// Type of Book
        /// </summary>
        public BookType Type { get; set; }

        /// <summary>
        /// Created Date/Time
        /// </summary>
        public DateTime Created { get; set; }
    }
}