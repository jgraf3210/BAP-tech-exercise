using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Queries;
using StargateAPI.Business.Data;
public class GetAstronautDutiesByNameTests
{
    private readonly Mock<StargateContext> _context;
    public Mock<GetAstronautDutiesByName> _getAstronautDutiesByName = new Mock<GetAstronautDutiesByName>();

    public GetAstronautDutiesByNameTests()
    {
        
    }


    [Fact]
    public void VerifyQueryOnlyReturnsRequestedData()
    {
        //Verify that the query only returns specific data when there are multiple records

    }


    [Fact]
    public void VerifyBadRequestWhenPersonDoesNotExist()
    {
        //Verify that a BadRequest error is thrown when the user does not exist
    }

}