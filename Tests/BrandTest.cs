using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore
{
  public class BrandTest : IDisposable
  {
    public BrandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=shoe_stores_test;Integrated Security=SSPI;";
    }

    public void Dispose()
    {
      Brand.DeleteAll();
    }

    [Fact]
    public void Test_EqualOverrideTrueForSameName()
    {

      //Arrange, Act
      Brand firstBrand = new Brand("Nike");
      Brand secondBrand = new Brand("Nike");

      //Assert
      Assert.Equal(firstBrand, secondBrand);
    }

    [Fact]
    public void Test_Save()
    {
      //Arrange
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      //Act
      List<Brand> result = Brand.GetAll();
      List<Brand> testList = new List<Brand>{testBrand};

      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_SaveAssignsIdToObject()
    {
      //Arrange
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      //Act
      Brand savedBrand = Brand.GetAll()[0];

      int result = savedBrand.GetId();
      int testId = testBrand.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_FindFindsBrandInDatabase()
    {
      //Arrange
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      //Act
      Brand foundBrand = Brand.Find(testBrand.GetId());

      //Assert
      Assert.Equal(testBrand, foundBrand);
    }
    [Fact]
    public void Test_GetStore_RetrievesAllStoreWithBrand()
    {
      Store testStore = new Store("GameStop");
      testStore.Save();
      Store testStore2 = new Store("Walmart");
      testStore2.Save();

      Brand firstBrand = new Brand("Nike");
      firstBrand.Save();

      testStore.AddBrand(firstBrand);
      testStore2.AddBrand(firstBrand);
      List<Store> testStoreList = new List<Store> {testStore, testStore2};
      List<Store> resultStoreList = firstBrand.GetStore();
      foreach(Store i in resultStoreList)
      {
        Console.WriteLine(i.GetName() + i.GetId());
      }
      Assert.Equal(testStoreList, resultStoreList);
    }

  }
}
