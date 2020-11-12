﻿namespace Alura.LeilaoOnlien.Core
{
    public class Interessada
    {
        public Interessada(string nome, Leilao leilao)
        {
            Nome = nome;
            Leilao = leilao;
        }

        public string Nome { get; }
        public Leilao Leilao { get; }
    }
}