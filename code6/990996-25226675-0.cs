    <Window.Resources>
        <viewModel:ViewModel x:Key="MyViewModel">
    </Window.Resource>
    <Window.DataContext>
        <Binding Source="{staticResource MyViewmodel}">
    </Window.DataContext>
    <Image ....>
        <Image.Style>
            <Style x:Name="ToggleAnimationStyle" Target=Image>
                <Style.Triggers>
                    <DataTrigger Binding={Binding CredentialsAreValid} Value="True">
                        <DataTrigger.EnterActions>
                             <BeginStoryboard>
                                  <Storyboard x:Name="FadeInStoryBoard">
                                         <DoubleAnimation Storyboard.TargetProperty="Opacity" From="1.0" To="0.0" FillBehavior="HoldEnd" BeginTime="0:0:0" Duration="0:0:3"/>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </DataTrigger.EnterActions>
                                <DataTrigger.ExitActions>
                                    <BeginStoryboard>
                                        <Storyboard x:Name="FadeOutStoryBoard">
                                            <DoubleAnimation Storyboard.TargetProperty="Opacity" From="0.0" To="1.0" FillBehavior="HoldEnd" BeginTime="0:0:0" Duration="0:0:10">
                                                <DoubleAnimation.EasingFunction>
                                                    <ExponentialEase EasingMode="EaseIn"/>
                                                </DoubleAnimation.EasingFunction>
                                            </DoubleAnimation>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </DataTrigger.ExitActions>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
