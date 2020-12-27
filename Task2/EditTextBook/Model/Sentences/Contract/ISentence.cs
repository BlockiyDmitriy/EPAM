﻿using EditTextBook.Model.Symbols;
using EditTextBook.Model.Words.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditTextBook.Model.Sentences.Contract
{
    internal interface ISentence
    {
        int Length { get; set; }
        void Add(ISentenceItem word);
        void Delete(ISentenceItem position);
    }
}
