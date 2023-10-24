public abstract class PushBehaviour : PushBehaviour {
	
    /* ATTRIBUTES */
	protected int ret;
	protected ETABSv1.cSapModel etabsModel;
	
    /* CONSTRUCTOR */
    //Overloaded
    public PushBehaviour(ETABSv1.cSapModel etabsModel) {
		this.etabsModel=etabsModel;}
	
    /* METHODS */
    //Implemented from the Interfaces
    public void push();

}
