/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders, HttpParams } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';
import { ProjectDto } from '../models/project-dto';
@Injectable({
  providedIn: 'root',
})
class ProjectService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
     * @return OK
     */
  ProjectGetResponse(): Observable<StrictHttpResponse<Array<ProjectDto>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Projects`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<ProjectDto>>;
      })
    );
  }
  /**
   * @return OK
   */
  ProjectGet(): Observable<Array<ProjectDto>> {
    return this.ProjectGetResponse().pipe(
      __map(_r => _r.body)
    );
  }

  /**
    * @param keySearch undefined
    * @param status undefined
    * @return OK
    */
  ProjectGetResponseWithKeySearch(params: ProjectService.ProjectGetHaveConditionParams): Observable<StrictHttpResponse<Array<ProjectDto>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    if (params.input != null) __params = __params.set('input', params.input.toString());
    if (params.status != null) __params = __params.set('status', params.status.toString());

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Projects/KeySearch`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<Array<ProjectDto>>;
      })
    );
  }
  /**
    * @param keySearch undefined
    * @param status undefined
    * @return OK
    */
  ProjectGetWithKeySearch(params: ProjectService.ProjectGetHaveConditionParams): Observable<Array<ProjectDto>> {
    return this.ProjectGetResponseWithKeySearch(params).pipe(
      __map(_r => _r.body)
    );
  }

  /**
   * @param project undefined
   * @return OK
   */
  ProjectPutResponse(project: ProjectDto): Observable<StrictHttpResponse<ProjectDto>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = project;
    let req = new HttpRequest<any>(
      'PUT',
      this.rootUrl + `/api/Projects`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<ProjectDto>;
      })
    );
  }
  /**
   * @param project undefined
   * @return OK
   */
  ProjectPut(project: ProjectDto): Observable<ProjectDto> {
    return this.ProjectPutResponse(project).pipe(
      __map(_r => _r.body)
    );
  }

  /**
   * @param project undefined
   * @return OK
   */
  ProjectPostResponse(project: ProjectDto): Observable<StrictHttpResponse<ProjectDto>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = project;
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Projects`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<ProjectDto>;
      })
    );
  }
  /**
   * @param project undefined
   * @return OK
   */
  ProjectsPost(project: ProjectDto): Observable<ProjectDto> {
    return this.ProjectPostResponse(project).pipe(
      __map(_r => _r.body)
    );
  }

  /**
   * @param id undefined
   * @return OK
   */
  ProjectGet_1Response(id: number): Observable<StrictHttpResponse<ProjectDto>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Projects/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<ProjectDto>;
      })
    );
  }
  /**
   * @param id undefined
   * @return OK
   */
  ProjectGet_1(id: number): Observable<ProjectDto> {
    return this.ProjectGet_1Response(id).pipe(
      __map(_r => _r.body)
    );
  }

  /**
   * @param id undefined
   */
  ProjectDeleteResponse(id: number): Observable<StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Projects/${id}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param id undefined
   */
  ProjectDelete(id: number): Observable<null> {
    return this.ProjectDeleteResponse(id).pipe(
      __map(_r => _r.body)
    );
  }

   /**
   * @param id undefined
   */
    ProjectMultipleDeleteResponse(id: Array<number>): Observable<StrictHttpResponse<null>> {
      let __params = this.newParams();
      let __headers = new HttpHeaders();
      let __body: any = null;
      __body = id;
      let req = new HttpRequest<any>(
        'DELETE',
        this.rootUrl + `/api/Projects/DeleteProjects`,
        __body,
        {
          headers: __headers,
          params: __params,
          responseType: 'json'
        });
  
      return this.http.request<any>(req).pipe(
        __filter(_r => _r instanceof HttpResponse),
        __map((_r) => {
          return _r as StrictHttpResponse<null>;
        })
      );
    }
    /**
     * @param id undefined
     */
    ProjectMultipleDelete(id: Array<number>): Observable<null> {
      return this.ProjectMultipleDeleteResponse(id).pipe(
        __map(_r => _r.body)
      );
    }
}

module ProjectService {
  export interface ProjectGetHaveConditionParams {
    input: string;
    status: number;
  }
}

export { ProjectService }
