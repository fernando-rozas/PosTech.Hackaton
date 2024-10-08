﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Cpf
    {

        public Cpf(string numero)
        {
            Numero = numero;
        }
        public string Numero { get; set; }

        public static bool ValidarCpf(Cpf cpf)
        {
            if (cpf.Numero.Length > 11) return false;

            while (cpf.Numero.Length != 11)
                cpf.Numero = '0' + cpf.Numero;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (cpf.Numero[i] != cpf.Numero[0])
                    igual = false;

            if (igual || cpf.Numero == "12345678909") return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf.Numero[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0) return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;
            return true;
        }
    }
}
