﻿using YG.Server.ExceptionStorage.DataBase.Models;

namespace YG.Server.ExceptionStorage.Services;

public interface IRootService
{
    public Task<Root?> CreateAsync(Root root);

    public Task<Root?> GetAsync(string id);

    public Task<IEnumerable<Root>> GetAllAsync();
    public Task<IEnumerable<Root>> GetRangeAsync(int offset, int count);
}
