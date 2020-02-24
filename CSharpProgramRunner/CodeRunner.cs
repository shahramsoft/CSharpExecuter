using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpProgramRunner
{
    public partial class CodeRunner : Form
    {
        public CodeRunner()
        {
            InitializeComponent();
        }

        private void BtnCodeExecuter_Click(object sender, EventArgs e)
        {
            try
            { 
                string source =TxtCode.Text;

            Dictionary<string, string> providerOptions = new Dictionary<string, string>
                {
                    {"CompilerVersion", "v3.5"}
                };
            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

            CompilerParameters compilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };

            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);

            if (results.Errors.Count != 0)
                throw new Exception("Mission failed!");

            object o = results.CompiledAssembly.CreateInstance("Kasra.General");
            MethodInfo mi = o.GetType().GetMethod("Execute");
            var objectArray = new object[]
            {1,"Test"
            };

            var reuslt = mi.Invoke(o, objectArray);
                var jsonOfObject = Newtonsoft.Json.JsonConvert.SerializeObject(reuslt);
                var resultModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ResultViewModel>(jsonOfObject);
                MessageBox.Show(resultModel.Validate.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

    }
    public class ResultViewModel
    {
        public bool Validate { get; set; }
        public string Message { get; set; }
    }
}
