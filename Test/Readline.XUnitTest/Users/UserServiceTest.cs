using Readline.Domain.Enums;
using Readline.Service.DTOs.Users;
using Readline.Service.Exceptions;
using Readline.Service.Interfaces;
using Readline.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readline.XUnitTest.Users;

public class UserServiceTest
{

    [Fact]
    public async void Calculator_two_number_returnsum()
    {
        //Avarage
        int a = 4;
        int b = 6;

        //Act
        var result = Add(a,b);

        //Asert
        Assert.Equal(result,10);
    }

    public int Add(int a, int b)
    {
        return a + b;
    }

}
