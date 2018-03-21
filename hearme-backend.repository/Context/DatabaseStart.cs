using System;
using Microsoft.EntityFrameworkCore;

namespace hearme_backend.repository.Context
{
    public class DatabaseStart
    {
        public static void DbStart(HearMeContext contexto)
        {
            contexto.Database.Migrate(); //Verifica se o banco já foi criado, caso não, o banco é criado.
            //Console.WriteLine("Criação do Banco:" + contexto.Database.EnsureCreated());
        }
    }
}