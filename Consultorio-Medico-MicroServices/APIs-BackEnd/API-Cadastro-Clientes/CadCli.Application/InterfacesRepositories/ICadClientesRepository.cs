using CadCli.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadCli.Application.InterfacesRepositories
{
    public interface ICadClientesRepository
    {
        Task Add(CadCliente cadCliente);
        //Task<ShippingOrder> GetByCodeAsync(string code);
        //Task AddAsync(ShippingOrder shippingOrder);
    }
}
