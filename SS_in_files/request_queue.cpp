#include "request_queue.h"
#include "search_server.h"
#include "document.h"

#include <vector>
#include <string>

using namespace std;
    vector<Document> RequestQueue::AddFindRequest(const string& raw_query, DocumentStatus status) {
        current_time++;
        if (current_time > min_in_day_)
        {
            requests_.pop_front();
            current_time--;
        }
        QueryResult result;
        result.documents_ = server_.FindTopDocuments(raw_query, status);
        requests_.push_back(result);
        return server_.FindTopDocuments(raw_query, status);
    }

    vector<Document> RequestQueue::AddFindRequest(const string& raw_query) {
        current_time++;
        if (current_time > min_in_day_)
        {
            requests_.pop_front();
            current_time--;
        }
        QueryResult result;
        result.documents_ = server_.FindTopDocuments(raw_query);
        requests_.push_back(result);
        return server_.FindTopDocuments(raw_query);
    }

    int RequestQueue::GetNoResultRequests() const {
        int invalid_requests = 0;
        for (const QueryResult& request : requests_)
        {
            if (request.documents_.empty())
            {
                invalid_requests++;
            }
        }
        return invalid_requests;
    }

