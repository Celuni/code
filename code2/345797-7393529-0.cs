	public interface IJobFactory
	{
		/// <summary> 
		/// Called by the scheduler at the time of the trigger firing, in order to
		/// produce a <see cref="IJob" /> instance on which to call Execute.
		/// </summary>
		/// <remarks>
		/// <p>
		/// It should be extremely rare for this method to throw an exception -
		/// basically only the the case where there is no way at all to instantiate
		/// and prepare the Job for execution.  When the exception is thrown, the
		/// Scheduler will move all triggers associated with the Job into the
		/// <see cref="TriggerState.Error" /> state, which will require human
		/// intervention (e.g. an application restart after fixing whatever 
		/// configuration problem led to the issue wih instantiating the Job. 
		/// </p>
		/// 
    /// </remarks>
		/// <param name="bundle">
		/// The TriggerFiredBundle from which the <see cref="JobDetail" />
		/// and other info relating to the trigger firing can be obtained.
		/// </param>
		/// <throws>  SchedulerException if there is a problem instantiating the Job. </throws>
		/// <returns> the newly instantiated Job
		/// </returns>
		IJob NewJob(TriggerFiredBundle bundle);
	}
