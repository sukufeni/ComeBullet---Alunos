namespace ComeBullet
{
    class ListaLixo
    {
        internal Lixo sentinela;

        public ListaLixo()
        {
            Lixo x = new Lixo();
            sentinela = x;
        }

        public void insereOcorrencia(string ocorrencia)
        {
            Lixo aux = sentinela;

            while(aux.proximo!= null)
            {
                aux = aux.proximo;
            }
            Lixo novo = new Lixo();
            novo.insereEvento(ocorrencia);
            novo.novaRacao();
            aux.proximo = novo;
        }
        public string percorrerLista()
        {
            Lixo aux = sentinela;
            while (aux.proximo != null)
            {
                aux = aux.proximo;
                return aux.racaoCriada +" - "+aux.evento;
            }
            return null;
        }
    }
}
