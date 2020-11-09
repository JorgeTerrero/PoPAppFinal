﻿using PopApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PopApp.Core.Interfaces.Services
{
    public interface IDocumentsServices
    {
        Task<IEnumerable<Document>> GetDocuments();
        Task<Document> GetDocument(int id);
        Task CreateDocument(Document document);
        Task UpdateDocument(int id, Document document);
        Task DeleteDocument(int id);
    }
}
