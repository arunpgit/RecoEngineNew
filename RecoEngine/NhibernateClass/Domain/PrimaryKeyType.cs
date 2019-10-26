﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhibernateclassGeneration.Domain
{
    public enum PrimaryKeyType
    {
        /// <summary>
        /// Primary key consisting of one column.
        /// </summary>
        PrimaryKey,
        /// <summary>
        /// Primary key consisting of two or more columns.
        /// </summary>
        CompositeKey,
        /// <summary>
        /// Default primary key type.
        /// </summary>
        Default = PrimaryKey
    }
}