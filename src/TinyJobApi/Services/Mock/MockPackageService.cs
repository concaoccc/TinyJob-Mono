using System;
using TinyJobApi.Models;

namespace TinyJobApi.Services;

public class MockPackageService : IPackageService
{
    public Task<IEnumerable<Package>> GetAllPackagesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Package?> GetPackageByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Package?> UpdatePackageByIdAsync(int id, Package package)
    {
        throw new NotImplementedException();
    }
}
