﻿using Entitiess.Models;
using Repositories.Contracts;
using Services.Contrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class BookManager : IBookService
{
    private readonly IRepositoryManager _manager;

    public BookManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public Book CreateOneBook(Book book)
    {
        if (book == null)
            throw new ArgumentNullException();

        _manager.Book.CreateOneBook(book);
        _manager.Save();
        return book;
    }


    public void DeleteOneBook(int id, bool trackChanges)
    {
        var entity = _manager.Book.GetOneBookById(id, false);
        if (entity == null)
            throw new Exception($"Book with id:{id} could not found");
        _manager.Book.DeleteOneBook(entity);
        _manager.Save();
    }

    public IEnumerable<Book> GetAllBooks(bool trackChanges) => _manager.Book.GetAllBooks(trackChanges);


    public Book GetOneBookById(int id, bool trackChanges) => _manager.Book.GetOneBookById(id, false);



    public void UpdateOneBook(int id, Book book, bool trackChanges)
    {
        var entity = _manager.Book.GetOneBookById(id, trackChanges);
        if (entity == null)
            throw new Exception($"Book with id:{id} could not found.");
        entity.Title = book.Title;
        entity.Price = book.Price;

        _manager.Book.UpdateOneBook(entity);
        _manager.Save();

    }
}
