namespace CovidApp
{
    public static class ResponseMessageGenerator
    {
        public static readonly Dictionary<ResponseStatusCodes, string> ResponseMessages = new Dictionary<ResponseStatusCodes, string>
        {
            {ResponseStatusCodes.Success,"Ok"},
            {ResponseStatusCodes.BadRequest,"Hatalı sorgu"},
            {ResponseStatusCodes.NotFound,"İlgili veri bulunamadı"},
            {ResponseStatusCodes.AccountCreateFail,"Böyle bir kullanıcı mevcut."},
            {ResponseStatusCodes.AccountCreateSuccess,"Hesap başarıyla oluşturuldu."},
            {ResponseStatusCodes.AccountDeleteFail,"Böyle bir kullanıcı bulunamadı"},
            {ResponseStatusCodes.AccountDeleteSuccess,"Hesap başarıyla silindi."},
            {ResponseStatusCodes.AccountUpdateFail,"Böyle bir kullanıcı bulunamadı"},
            {ResponseStatusCodes.AccountUpdateSuccess,"Hesap başarıyla güncellendi."},
            {ResponseStatusCodes.AccountUpdatePhoneNumberFail,"Bu telefon numarası ile kayıtlı kullanıcı bulunamadı."},
            {ResponseStatusCodes.AccountUpdatePhoneNumberSuccess,"Telefon numarası başarıyla güncellendi"},
            {ResponseStatusCodes.AccountChangeIsBlockFail,"Böyle bir kullanıcı bulunamadı."},
            {ResponseStatusCodes.AccountChangeIsBlockSuccess,"Başarıyla güncellendi"},
            {ResponseStatusCodes.AccountChangeVisibilityFail,"Böyle bir kullanıcı bulunamadı."},
            {ResponseStatusCodes.AccountChangeVisibilitySuccess,"Başarıyla güncellendi"},
        };

        public static string MessageGenerator(ResponseStatusCodes responseStatusCodes)
        {
            return ResponseMessages[responseStatusCodes];
        }
    }
}