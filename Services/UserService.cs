namespace ExceptionHandlerAndSerilog.WebAPI.Services;

public sealed class UserService
{
    public (bool, string) Create(int age)
    {
        //int a = age;
        //int b = 0;
        //int c = a / b;
        if (age < 18)
        {

            //return (false, "Kullanıcnın yaşı 18 den büyük olmalı");
            throw new Exception("Kullanıcının yaşı 18 den büyük olmalı");
        }
        return (true, string.Empty);


    }
}
