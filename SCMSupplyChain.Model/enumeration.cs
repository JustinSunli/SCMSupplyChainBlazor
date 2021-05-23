
namespace SCMSupplyChain.Model
{

    /// <summary>
    /// 出入库记录
    /// </summary>
    public enum IODType
    {
        入库 = 1,
        出库 = 2
    }

    /// <summary>
    /// 客户表
    /// </summary>
    public enum CusGrade
    {
        VIP1,
        VIP2,
        VIP3,
        VIP4,
        VIP5,
    }

    /// <summary>
    /// 客户订单
    /// </summary>
    public enum COState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 盘点单
    /// </summary>
    public enum CDState
    {
        盘点中 = 1,
        盘点核算,
        盘点结束
    }


    /// <summary>
    /// 采购入库
    /// </summary>
    public enum SIDData
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 采购单
    /// </summary>
    public enum StockState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 其他出库单
    /// </summary>
    public enum OODState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 报损单
    /// </summary>
    public enum LostState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 其它入库单
    /// </summary>
    public enum OIDState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 报溢单
    /// </summary>
    public enum POState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 报价单
    /// </summary>
    public enum QPState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 生产领料单
    /// </summary>
    public enum PODState
    {
        未定义1,
        未定义2,
        未定义3,
    }
    /// <summary>
    /// 生产入库单
    /// </summary>
    public enum PIDState
    {
        未定义1,
        未定义2,
        未定义3,
    }


    /// <summary>
    /// 销售出库单
    /// </summary>
    public enum SDState
    {
        未定义1,
        未定义2,
        未定义3,
    }

    /// <summary>
    /// 销售退货单
    /// </summary>
    public enum SRState
    {
        未定义1,
        未定义2,
        未定义3,
    }
}
