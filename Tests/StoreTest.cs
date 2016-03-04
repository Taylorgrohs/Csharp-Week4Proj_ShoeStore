using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ShoeStore
{
  public class StoreTest : IDisposable
  {
    public StoreTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=shoe_stores_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void test_StoresEmptyAtFirst()
    {
      int result = Store.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      Store firstStore = new Store("GameStop");
      Store secondStore = new Store("GameStop");

      Assert.Equal(firstStore, secondStore);
    }

    [Fact]
    public void Test_Save_SavesStoreToDatabase()
    {
      Store testStore = new Store("GameStop");
      testStore.Save();

      List<Store> result = Store.GetAll();
      List<Store> testList = new List<Store>{testStore};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Save_AssignsIdToStoreObject()
    {
      Store testStore = new Store("GameStop");
      testStore.Save();

      Store savedStore = Store.GetAll()[0];

      int result = savedStore.GetId();
      int testId = testStore.GetId();

      Assert.Equal(testId, result);
    }
    [Fact]
    public void Test_Find_FindsStoreInDatabase()
    {
      //Arrange
      Store testStore = new Store("GameStop");
      testStore.Save();

      //Act
      Store foundStore = Store.Find(testStore.GetId());

      //Assert
      Assert.Equal(testStore, foundStore);
    }

    [Fact]
    public void Test_GetBrand_RetrievesAllBrandWithStore()
    {
      Store testStore = new Store("GameStop");
      testStore.Save();

      Brand firstBrand = new Brand("Nike");
      firstBrand.Save();
      Brand secondBrand = new Brand("Vans");
      secondBrand.Save();

      testStore.AddBrand(firstBrand);
      testStore.AddBrand(secondBrand);
      List<Brand> testBrandList = new List<Brand> {firstBrand, secondBrand};
      List<Brand> resultBrandList = testStore.GetBrand();

      Assert.Equal(testBrandList, resultBrandList);
    }


    [Fact]
    public void Test_AddBrand_AddsBrandToStore()
    {
      //Arrange
      Store testStore = new Store("GameStop");
      testStore.Save();

      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      Brand testBrand2 = new Brand("Vans");
      testBrand2.Save();

      //Act
      testStore.AddBrand(testBrand);
      testStore.AddBrand(testBrand2);

      List<Brand> result = testStore.GetBrand();
      List<Brand> testList = new List<Brand>{testBrand, testBrand2};

      //Assert
      Assert.Equal(testList, result);
}

    [Fact]
     public void Test_Delete_DeletesStoreFromDatabase()
     {
       //Arrange
       Store testStore1 = new Store("GameStop");
       testStore1.Save();

       Store testStore2 = new Store("Walmart");
       testStore2.Save();

       //Act
       testStore1.Delete();
       List<Store> resultStores = Store.GetAll();
       List<Store> testStoreList = new List<Store> {testStore2};

       //Assert
       Assert.Equal(testStoreList, resultStores);
     }

    [Fact]
    public void Test_Delete_DeletesStoreAssociationsFromDatabase()
    {
      Brand testBrand = new Brand("Nike");
      testBrand.Save();

      Store testStore = new Store("Footlocker");
      testStore.Save();

      testStore.AddBrand(testBrand);
      testStore.Delete();

      List<Store> resultBrandStores = testBrand.GetStore();
      List<Store> testBrandStores = new List<Store> {};

      Assert.Equal(testBrandStores, resultBrandStores);
    }

    public void Dispose()
    {
      Brand.DeleteAll();
      Store.DeleteAll();
    }
  }
}
