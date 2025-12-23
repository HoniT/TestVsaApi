using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace src.Features.Files.Upload
{
    public record FileUploadCommand(IFormFileCollection files, HttpContext context)
        : IRequest<IResult>;
}