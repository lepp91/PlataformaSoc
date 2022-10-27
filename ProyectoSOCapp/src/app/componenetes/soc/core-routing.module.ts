import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SocComponent } from './soc.component';



const routes: Routes = [
  {path:'SOC',
  component: SocComponent},
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
