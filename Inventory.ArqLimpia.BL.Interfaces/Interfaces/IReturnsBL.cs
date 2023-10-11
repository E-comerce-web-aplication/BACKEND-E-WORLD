using static Inventory.ArqLimpia.BL.DTOs.ReturnDTOs;



namespace Inventory.ArqLimpia.BL.Interfaces.Interfaces
{
    public  interface IReturns
    {
        Task<createReturnInputDTO> Create(createReturnOutputDTO pReturn);
        Task<findReturnInputDTO> Find(findReturnOutputDTO pReturn);
        Task< cancelReturnInputDTO> Cancel (cancelReturnOutputDTO pReturn);
    }
}
