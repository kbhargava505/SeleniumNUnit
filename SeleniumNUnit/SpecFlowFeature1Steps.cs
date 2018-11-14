using System;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SeleniumNUnit
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private int result=0;
        private  Calculator Calc1=new Calculator();
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            Calc1.add(p0);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {

            result = Calc1.result;
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
           Assert.AreEqual(p0,result);
        }
    }

    public class Calculator
    {

        public int result=0;
        public void add(int i)
        {
            result = i + result;
        }
    }
}
