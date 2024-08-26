using System;
using TinyJobApi.Data;
using TinyJobApi.Database.Entity;

namespace TinyJobApi.Services;

public class PackageServiceImp : IPackageService
{
    private readonly AppDbContext _appDbContext;

    public PackageServiceImp(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public Task<int> CreatePackageAsync(PackageDo packageDo)
    {
        _appDbContext.Packages.Add(packageDo);
        return Task.FromResult(_appDbContext.SaveChanges());
    }

    public Task DeletePackageByIdAsync(int id)
    {
        var package = _appDbContext.Packages.FirstOrDefault(p => p.Id == id);
        if (package != null)
        {
            _appDbContext.Packages.Remove(package);
            return Task.FromResult(_appDbContext.SaveChanges());
        }

        return Task.CompletedTask;
    }

    public Task<IEnumerable<PackageDo>> GetAllPackagesAsync()
    {
        return Task.FromResult<IEnumerable<PackageDo>>(_appDbContext.Packages);
    }

    public Task<PackageDo?> GetPackageByIdAsync(int id)
    {
        return Task.FromResult(_appDbContext.Packages.FirstOrDefault(p => p.Id == id));
    }

    public Task<PackageDo?> UpdatePackageByIdAsync(int id, PackageDo packageDo)
    {
        var existingPackage = _appDbContext.Packages.FirstOrDefault(p => p.Id == id);
        if (existingPackage != null)
        {
            existingPackage.Name = packageDo.Name;
            existingPackage.Description = packageDo.Description;
            existingPackage.RelativePath = packageDo.RelativePath;
            existingPackage.StorageAccount = packageDo.StorageAccount;
            existingPackage.Version = packageDo.Version;
            existingPackage.UpdateTime = DateTime.Now;
            _appDbContext.SaveChanges();
            return Task.FromResult<PackageDo?>(existingPackage);
        }

        return Task.FromResult<PackageDo?>(null);
    }
}
