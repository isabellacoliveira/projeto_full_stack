using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }

        // podemos passar a mensagem, com {0} ele pega o nome do campo 
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        // [MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caractéres"),
        // MaxLength(3, ErrorMessage = "{0} deve ter no máximo 50 caractéres")]
        StringLength(50, MinimumLength = 3, 
                        ErrorMessage = "Intervalo permitido de 3 a 50 caractéres")
        ]
        public string Tema { get; set; }

        [Display(Name = "Qtd pessoas"), 
        Range(1, 120000, ErrorMessage ="{0} não pode ser menor que 1 e maior que 120.000")]
        public int QtdPessoas { get; set; }

           [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
                           ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")] // erro de invalid pattern
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "o campo {0} é obrigatório"), 
        Phone(ErrorMessage = "o campo {0} está com número inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        Display(Name = "e-mail"),
        EmailAddress(ErrorMessage = "O campo {0} precisa ser um email válido")]
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    
    }
}