import { ErrorHandler, Inject, Injector } from "@angular/core";
import { ToastrService } from "ngx-toastr";

export class AppErrorHandler extends ErrorHandler {
    constructor(@Inject(Injector) private injector: Injector) { 
        super();
    }

    private get toastr(): ToastrService {
        return this.injector.get(ToastrService);
    }
    // constructor(@Inject(ToastrService) private toastr: ToastrService) {
    // }
    handleError(error: any): void {
        console.log("Toaster error");
      this.toastr.error('An unexpected error occured!', 'Error',{ timeOut: 3000 })
      //console.log("An error occured");
    }
}