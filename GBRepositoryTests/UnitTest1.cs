using GoldBadgeChallenge.Data.Entities;
using GoldBadgeChallenge.Data.Entities.Enums;
using GoldBadgeChallenge.Repository;

namespace GBRepositoryTests;

public class UnitTest1
{
    private DeliveryRepository _repo;

    public UnitTest1()
    {
        _repo = new DeliveryRepository();
    }
    [Fact]
    public void AddDelivery_ShouldReturnTrue()
    {
        //Arrange

        //Act
        Delivery delivery4 = new Delivery(new DateTime(2023, 10, 18), new DateTime(2023, 10, 27), 1, 03, 1001, OrderStatus.Enroute);

        bool success=_repo.AddDelivery(delivery4);
        //Assert
        Assert.True(success);
    }
    [Fact]
    public void UpdateRouteStatus_ShouldReturnTrue()
    {
        //Arrange

        //Act
        Delivery deliveryFromDb = _repo.GetDeliveries()[1];
        bool success= _repo.UpdateRouteStatus(deliveryFromDb.Id,OrderStatus.Scheduled);


        //Assert
        Assert.True(success);   
    }
    [Fact]
    public void RemoveDeliveryFromList_ShouldReturnTrue()
    {
        //Arrange

        //Act
        //We are grabbing the second delivery in the list
        Delivery deliveryFromDb = _repo.GetDeliveries()[1];
        bool success= _repo.RemoveDeliveryFromList(deliveryFromDb);

        //Assert   
        Assert.True(success);
    }
}