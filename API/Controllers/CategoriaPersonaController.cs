using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class CategoriaPersonaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    //[Authorize(Roles = "Administrator,Employee")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriaPersonaDto>>> Get1()
    {
        var results = await _unitOfWork.CategoriaPersonas
                                    .GetAllAsync();
        return _mapper.Map<List<CategoriaPersonaDto>>(results);
    }

    [HttpGet("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaPersonaDto>> Get2(int id)
    {
        var result = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
        return _mapper.Map<CategoriaPersonaDto>(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaPersona>> Post(CategoriaPersonaDto resultDto)
    {
        var result = _mapper.Map<CategoriaPersona>(resultDto);
        this._unitOfWork.CategoriaPersonas.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
        {
            return BadRequest();
        }
        resultDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { id = resultDto.Id }, resultDto);
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaPersona>> Put(int id, [FromBody] CategoriaPersonaDto resultDto)
    {
        var result = _mapper.Map<CategoriaPersona>(resultDto);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.CategoriaPersonas.Update(result);
        await _unitOfWork.SaveAsync();
        return result;
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Administrator,Employee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        _unitOfWork.CategoriaPersonas.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    // [HttpGet]
    // [MapToApiVersion("1.1")]
    // //[Authorize(Roles = "Administrator,Employee")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<CategoriaPersonaDto>>> GetPag([FromQuery] Params resultParams)
    // {
    //     var result = await _unitOfWork.CategoriaPersonas.GetAllAsync(resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
    //     var lstResultDto = _mapper.Map<List<CategoriaPersonaDto>>(result.registros);
    //     return new Pager<CategoriaPersonaDto>(lstResultDto, result.totalRegistros, resultParams.PageIndex, resultParams.PageSize, resultParams.Search);
    // }
}