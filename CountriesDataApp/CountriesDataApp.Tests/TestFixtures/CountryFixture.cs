namespace CountriesDataApp.Tests.TestFixtures
{
    public static class CountryFixture
    {
        public static IEnumerable<Country> GetCountriesEU()
        {
            return new List<Country>()
            {
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Germany",
                        Official = "Federal Republic of Germany",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Deutschland",
                                    Official = "Bundesrepublik Deutschland"
                                }
                            }
                        }
                    },
                    Population = 83240525,
                    Area = 357114,
                    TLD = new List<string>()
                    {
                        ".de"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "France",
                        Official = "French Republic",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "France",
                                    Official = "République française"
                                }
                            }
                        }
                    },
                    Population = 67391582,
                    Area = 551695,
                    TLD = new List<string>()
                    {
                        ".fr"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Denmark",
                        Official = "Kingdom of Denmark",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Danmark",
                                    Official = "Kongeriget Danmark"
                                }
                            }
                        }
                    },
                    Population = 5831404,
                    Area = 43094,
                    TLD = new List<string>()
                    {
                        ".dk"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Italy",
                        Official = "Italian Republic",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Italia",
                                    Official = "Repubblica italiana"
                                }
                            }
                        }
                    },
                    Population = 59554023,
                    Area = 301336,
                    TLD = new List<string>()
                    {
                        ".it"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Spain",
                        Official = "Kingdom of Spain",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "España",
                                    Official = "Reino de España"
                                }
                            }
                        }
                    },
                    Population = 47351567,
                    Area = 505992,
                    TLD = new List<string>()
                    {
                        ".es"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Poland",
                        Official = "Republic of Poland",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Polska",
                                    Official = "Rzeczpospolita Polska"
                                }
                            }
                        }
                    },
                    Population = 37950802,
                    Area = 312679,
                    TLD = new List<string>()
                    {
                        ".pl"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Romania",
                        Official = "Romania",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "România",
                                    Official = "România"
                                }
                            }
                        }
                    },
                    Population = 19286123,
                    Area = 238391,
                    TLD = new List<string>()
                    {
                        ".ro"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Netherlands",
                        Official = "Kingdom of the Netherlands",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Nederland",
                                    Official = "Koninkrijk der Nederlanden"
                                }
                            }
                        }
                    },
                    Population = 16655799,
                    Area = 41850,
                    TLD = new List<string>()
                    {
                        ".nl"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Belgium",
                        Official = "Kingdom of Belgium",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Belgien",
                                    Official = "Königreich Belgien"
                                }
                            }
                        }
                    },
                    Population = 11555997,
                    Area = 30528,
                    TLD = new List<string>()
                    {
                        ".be"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Greece",
                        Official = "Hellenic Republic",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Ελλάδα",
                                    Official = "Ελληνική Δημοκρατία"
                                }
                            }
                        }
                    },
                    Population = 10715549,
                    Area = 131990,
                    TLD = new List<string>()
                    {
                        ".gr"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Czechia",
                        Official = "Czech Republic",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Česko",
                                    Official = "Česká republika"
                                }
                            }
                        }
                    },
                    Population = 10698896,
                    Area = 78865,
                    TLD = new List<string>()
                    {
                        ".cz"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Malta",
                        Official = "Republic of Malta",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "Malta",
                                    Official = "Republic of Malta"
                                }
                            }
                        }
                    },
                    Population = 525285,
                    Area = 316,
                    TLD = new List<string>()
                    {
                        ".mt"
                    }
                },
                new Country()
                {
                    Name = new CountryName()
                    {
                        Common = "Mexico",
                        Official = "United Mexican States",
                        NativeName = new Dictionary<string, CountryNativeName>()
                        {
                            {
                                "tc", new CountryNativeName()
                                {
                                    Common = "México",
                                    Official = "Estados Unidos Mexicanos"
                                }
                            }
                        }
                    },
                    Population = 128932753,
                    Area = 1964375,
                    TLD = new List<string>()
                    {
                        ".mx"
                    }
                }
            };
        }
    }
}