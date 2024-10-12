﻿using AutoMapper;
using GenericService;

public class GenericService<TMODEL,TDATA> : IGenericService<TMODEL> 
    where TMODEL : class 
    where TDATA : class
{
    private readonly IRepository<TDATA> _repository;
    private readonly IMapper _mapper;

    public GenericService(IRepository<TDATA> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
 
    public async Task<int> AddAsync(TMODEL entity)
    {
        var dataEntity = _mapper.Map<TDATA>(entity);
        await _repository.AddAsync(dataEntity);

        var idValue = entity.GetType().GetProperty("Id")?.GetValue(entity);

        if (idValue != null)
        {
            // Eccezione
        }

        return (int)idValue!;
    }

    public async Task UpdateAsync(TMODEL entity)
    {
        var dataEntity = _mapper.Map<TDATA>(entity);
        await _repository.UpdateAsync(dataEntity);
    }

    public async Task DeleteAsync(int id)
    {
        var dataEntity = await _repository.GetByIdAsync(id);
        if (dataEntity == null)
        {
            // Gestione dato non trovato!
        }

        await _repository!.DeleteAsync(id);
    }
}