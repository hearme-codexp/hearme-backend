using System;
using Microsoft.EntityFrameworkCore;

namespace hearme_backend.repository.Context
{
    public class DatabaseStart
    {
        public static void DbStart(HearMeContext contexto)
        {
            contexto.Database.EnsureCreated();
            //Verifica se o banco já foi criado, caso não, o banco é criado.
            contexto.Database.Migrate();
        }
    }
}