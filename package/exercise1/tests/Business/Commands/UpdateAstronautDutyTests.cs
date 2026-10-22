
public class UpdateAstronautDutyTests
{
    
    public UpdateAstronautDutyTests()
    {
        
    }

    [Fact]
    public void VerifyUpdateRunsCorrectly()
    {
        //Verify that the update runs correctly and updates the proper tables and record
    }
    
    [Fact]
    public void VerifyBadRequestWhenPersonDoesNotExist()
    {
        //Verify that a BadRequest error is thrown when the requested user does not exist in the database
    }

    [Fact]
    public void VerifyBadRequestWhenUserDoesNotHaveAnAssignedDuty()
    {
        //Verify that a BadRequest error is sent when a user doesn't already have an assigned AstronautDuty
    }


}