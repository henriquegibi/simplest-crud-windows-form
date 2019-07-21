namespace simplest_crud_windows_form.Migrations
{
    using simplest_crud_windows_form.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<simplest_crud_windows_form.Models.MyBDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(simplest_crud_windows_form.Models.MyBDContext context)
        {
            IList<Detail> defaultDetail = new List<Detail>();

            defaultDetail.Add(new Detail() { Nome = "José", Sobrenome="Souza", Idade = 1, Endereco = "Rua X", DataNasc = DateTime.Now });
            defaultDetail.Add(new Detail() { Nome = "Maria", Sobrenome = "Silva", Idade = 2, Endereco = "Rua Y", DataNasc = DateTime.Now });
            defaultDetail.Add(new Detail() { Nome = "Juan", Sobrenome = "Gonzalo", Idade = 3, Endereco = "Rua Z", DataNasc = DateTime.Now });

            context.Details.AddRange(defaultDetail);

            base.Seed(context);
        }
    }
}
