using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    // IBookRepository'yi tembel yükleme ile saklayan özel ve sadece okunabilir değişken
    private readonly Lazy<IBookRepository> _bookRepository;

    // RepositoryManager sınıfının yapıcı metodu
    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
        _bookRepository=new Lazy<IBookRepository>(()=>new BookRepository(_context));
        // _bookRepository, yeni bir Lazy&lt;IBookRepository&gt; nesnesi olarak atanır
        // BookRepository nesnesi, sadece ihtiyaç duyulduğunda oluşturulacak
    }

    // IBookRepository'yi dönen yalnızca okunabilir özellik (property)
    // Bu özellik çağrıldığında, Lazy<IBookRepository> içindeki nesne döndürülür
    public IBookRepository Book => new BookRepository(_context);

    public void Save()
    {
        _context.SaveChanges();
    }
}
