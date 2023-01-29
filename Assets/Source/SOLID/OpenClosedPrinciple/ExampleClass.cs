namespace SDAZDGAMEpol5.SOLID.OpenClosedPrinciple
{
    /// <summary>
    ///     Open for Extension, Closed for Modification
    /// </summary>
    // Open for Extension - class can be inherited from
    public class ExampleClass
    {
        // Closed for Modification - constant value
        public const int SomeConstant = 42;

        // Closed for Modification - readonly field
        public readonly int ReadonlyField = 50;

        // Closed for Modification - get-only property
        public int GetOnlyProperty { get; } = 100;
        
        // Closed for Modification - encapsulated members
        private int PrivateProperty { get; set; }
        
        // Open for Extension - non-private overrideable method
        public virtual void MethodThatCanBeOverriden() // in abstract classes, it can also be an abstract method
        {
            
        }

        // Closed for Modification - non-overridable method
        public void MethodThatCannotBeOverriden()
        {
            
        }

        // Closed for Modification - private method
        private void PrivateMethod()
        {
            
        }

        public virtual string Name => "Example Class Name";
    }
}