using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;

namespace DiplomadoBotsQnAMaker.Dialogs
{
    [Serializable]
    public class QnADialog : QnAMakerDialog
    {
        public QnADialog () : base(new QnAMakerService(new QnAMakerAttribute(ConfigurationManager.AppSettings["QnASubscriptionKey"], ConfigurationManager.AppSettings["QnAKnowledgebaseId"], "No entendí la referencia :v",0.5)))
        {

        }

        protected override async Task RespondFromQnAMakerResultAsync(IDialogContext context, IMessageActivity message, QnAMakerResults result)
        {
            var primeraRespuesta = result.Answers.First().Answer;

            Activity respuesta = ((Activity)context.Activity).CreateReply();

            var datosRespuesta = primeraRespuesta.Split(';');

            if (datosRespuesta.Length == 1)
            {
                await context.PostAsync(primeraRespuesta);
                return;
            }

            var titulo = datosRespuesta[0];

            var descripcion = datosRespuesta[1];

            var url = datosRespuesta[2];

            var urlimagen = datosRespuesta[3];

            HeroCard card = new HeroCard
            {
                Title = titulo,
                Subtitle = descripcion
            };

            card.Buttons = new List<CardAction>
            {
                new CardAction(ActionTypes.OpenUrl,"ADVIT.CL", value:url)
            };

        }
    }
}