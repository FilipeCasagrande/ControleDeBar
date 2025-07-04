﻿using System.Text.RegularExpressions;
using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloGarçons
{
    public class Garcon : EntidadeBase<Garcon>
    {
        public string Nome;
        public string CPF;

        public Garcon(string nome, string CPF)
        {
            Nome = nome;
            this.CPF = CPF;
        }

        public override void AtualizarRegistro(Garcon registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            CPF = registroAtualizado.CPF;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Nome.Length < 3)
            erros += "O campo \"Nome\" deve conter pelomenos 3 caracteres.\n";

            if (!Regex.IsMatch(CPF, @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$")) 
                erros += "\"O campo \\\"CPF\\\" deve seguir o padrão 000.000.000-00.\";";

            return erros;

        }
    }
}
