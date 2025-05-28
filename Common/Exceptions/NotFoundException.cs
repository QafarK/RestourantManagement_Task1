﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions;

public class NotFoundException : Exception
{
	public NotFoundException(Type type, int id) : base($"{type} not found with id : {id}")
	{

	}
}