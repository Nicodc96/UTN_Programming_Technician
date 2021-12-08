namespace Entidades.Enumerado
{
    /// <summary>
    /// Tipos de placa de video.
    /// </summary>
    public enum ETipoPlaca { IntegradaMother, IntegradaCPU, PlacaExterna }
    /// <summary>
    /// Tipos de Motherboards
    /// </summary>
    public enum ETipoMother { Normal, Gaming, GamingRGB}
    /// <summary>
    /// Identificador del socket pertenenciente a un motherboard.
    /// </summary>
    public enum ESocket { AM3, AM4, FM2, LGA1150, LGA1151, LGA1200 }
    /// <summary>
    /// Tipos de Fuentes. El tipo varia en su tamaño.
    /// </summary>
    public enum ETipoFuente { ATX, SFX, SFX_L, TFX }
    /// <summary>
    /// Tipos de Memorias, para Notebooks/Netbooks o de PC de escritorio.
    /// </summary>
    public enum ETipoMemoria { SODIMM, DIMM }
    /// <summary>
    /// Identificador de la técnologia de memoria RAM según la generación.
    /// </summary>
    public enum ETecnologiaMemoria { DDR, DDR2, DDR3, DDR4, DDR5 }
    /// <summary>
    /// Tipos de discos de almacenamiento de datos.
    /// </summary>
    public enum ETipoDisco { SSD, HDD, SSHD, NVMeM_2 }
    /// <summary>
    /// Nombres de los dos principales fabricantes de microprocesadores.
    /// </summary>
    public enum EFabricanteCPU { AMD, INTEL }
    /// <summary>
    /// Cantidad de núcleos fisicos que contiene un procesador
    /// </summary>
    public enum ECantidadNucleos { Single_Core = 1, Dual_Core = 2, Quad_Core = 4, Octa_Core = 8}
    /// <summary>
    /// Nombres de las marcas más conocidas dentro del mundo de los componentes electrónicos para PC.
    /// </summary>
    public enum EMarcas { HyperX, Kingston, Corsair, ADATA, GSkill, MSI, Gigabyte, Sapphire, XFX, Zotac, ASRock, PNY, Sentey, Thermaltake, EVGA, CoolerMaster, ASUS, Biostar, WesternDigital, Seagate, Intel_Core, Ryzen }
}
