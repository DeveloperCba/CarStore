namespace CarStore.Core.Messages.Integration;

public  class SendEmailIntegrationEvent : IntegrationEvent
{
    public string Origem { get; private set; }
    public string Destino { get; private set; }
    public string Assunto { get; private set; }
    public string Mensagem { get; private set; }

    public SendEmailIntegrationEvent(string origem, string destino, string assunto, string mensagem)
    {
        Origem = origem;
        Destino = destino;
        Assunto = assunto;
        Mensagem = mensagem;
    }
}
