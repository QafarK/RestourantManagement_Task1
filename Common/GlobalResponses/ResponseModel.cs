﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.GlobalResponses;

public class ResponseModel
{
	public bool IsSuccess { get; set; }
	public List<string> Errors { get; set; }

	public ResponseModel(List<string> messages)
	{
		Errors = messages;
		IsSuccess = false;
	}

	public ResponseModel()
	{
		IsSuccess = true;
		Errors = null;
	}
}
