using DAL.Entities;
using Repository;

//Console.WriteLine("Hello, World!");
Users newUser = new()
{
    Name = "Baris",
    LastName = "Manco",
    UserName = "bmanco",
    Email = "baris@barismanco.com",
    PasswordHash = "12345",
    Gsm = "3334",
    IsAdmin = true
};
using (GeneralRepository<Users> repository = new())
{
    repository.Insert(newUser, true);
}
