namespace Xbam.Inspector.Data {

  public partial class InspectorFamilyTab {
    public abstract partial class Type : InspectorTabData.Type {
      protected Type(string uniqueIdentifier) : base(uniqueIdentifier) {}
    }
  }
}
