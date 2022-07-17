#pragma once
#include "search_server.h"
#include "document.h"

#include <vector>
#include <string>
#include <deque>

class RequestQueue {
public:
    explicit RequestQueue(const SearchServer& search_server) : server_(search_server) {}

    template <typename DocumentPredicate>
    std::vector<Document> AddFindRequest(const std::string& raw_query, DocumentPredicate document_predicate) {
        current_time++;
        if (current_time > min_in_day_)
        {
            requests_.pop_front();
            current_time--;
        }
        QueryResult result;
        result.documents_ = server_.FindTopDocuments(raw_query);
        requests_.push_back(result);
        return server_.FindTopDocuments(raw_query, document_predicate);
    }

    std::vector<Document> AddFindRequest(const std::string& raw_query, DocumentStatus status);

    std::vector<Document> AddFindRequest(const std::string& raw_query);

    int GetNoResultRequests() const;
private:
    struct QueryResult {
        std::vector<Document> documents_;
    };
    const static int min_in_day_ = 1440;
    int current_time = 0;
    std::deque<QueryResult> requests_;
    const SearchServer& server_;
};

