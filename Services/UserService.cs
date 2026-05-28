namespace ExceptionHandlerAndSerilog.WebAPI.Services;

public sealed class UserService
{
    public (bool, string) Create(int age)
    {
        try
        {
            if (age < 18)
            {
                int a = age;
                int b = 0;
                int c = a / b;
                return (false, "Kullanıcnın yaşı 18 den büyük olmalı");
                //throw new Exception("Kullanıcnın yaşı 18 den büyük olmalı");
            }
            return (true, string.Empty);
        }
        catch (Exception ex)
        {

            return (false, ex.Message);
        }

    }
}
