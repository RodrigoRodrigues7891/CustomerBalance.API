using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerBalance.Shared.Data.Data;

public class DAL<T> where T : class
{
    private readonly CustomerLedgerContext context;

    public DAL(CustomerLedgerContext context)
    {
        this.context = context;
    }
    public IEnumerable<T> GetListByFilter(Func<T, bool> condicao)
    {
        return context.Set<T>().Where(condicao);
    }
    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }

    /*
    public async Task<IEnumerable<T>> ListarPaginado(int page, int pageSize)
    {
        if (page <= 0) page = 1;
        if (pageSize < 0) pageSize = 0;

        return await this.context.Set<T>()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        await context.SaveChangesAsync();
    }
    public async Task Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        await context.SaveChangesAsync();
    }
    public async Task Deletar(T objeto)
    {
        context.Set<T>().Remove(objeto);
        await context.SaveChangesAsync();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

    public decimal SumBy(Expression<Func<T, bool>> condition, Expression<Func<T, decimal>> selector)
    {
        return context.Set<T>().Where(condition).Sum(selector);
    }
    */
}
