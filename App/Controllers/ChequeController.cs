namespace App.Controllers
{
    using System;
    using System.Web.Http;

    using CurrencyToWords;

    [RoutePrefix("api/cheque")]
    public class ChequeController : ApiController
    {
        private readonly ICurrencyWordService wordService;

        public ChequeController(ICurrencyWordService wordService)
        {
            this.wordService = wordService;
        }

        [HttpGet]
        [Route("{amount}/amount")]
        public IHttpActionResult ConvertChequeAmount([FromUri] decimal amount)
        {
            if (amount < 0)
                return BadRequest("Invalid amount");

            var currencyWord = wordService.ConvertToWord(amount);

            if (String.IsNullOrEmpty(currencyWord))
                return NotFound();

            return Ok(currencyWord);
        }
    }
}
